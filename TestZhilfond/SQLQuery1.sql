create trigger Balances_InBalance on Balances after insert
as
begin
declare @date_start date;
declare @date_end date;
declare @payment_summ float;
declare @payment_last float;
declare @in_balance float;
declare @id int;
declare @abonent_id int;

select @id = (select Id from inserted);
select @abonent_id = (select AccountId from inserted);

select @date_end = (select Period from inserted);
select @date_start = (select dateadd(month, -1, @date_end));
select @payment_summ = (select sum(Summ) from Payments where AccountId = @abonent_id and Date between @date_start and @date_end);

if (@payment_summ is null) select @payment_summ = 0;

select @payment_last = (select top(1) Calculation from Balances where Id < @id and AccountId = @abonent_id order by Id desc) +  (select top(1) In_balance from Balances where Id < @id and AccountId = @abonent_id order by Id desc);

select @in_balance = @payment_last - @payment_summ;

update Balances set In_balance = @in_balance where Id = @id;
end