create or alter trigger Balances_InBalance on Balances after insert
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

/*	вычисляем, проводилась ли оплата за прошлый период и сколько	*/
select @payment_summ = (select sum(Summ) from Payments where AccountId = @abonent_id and Date between @date_start and @date_end);

if (@payment_summ is null) select @payment_summ = 0;

/*	вычисляем, сколько было всего начислено с учетом сальдо за предыдущий период	*/
select @payment_last = (select top(1) Calculation from Balances where Id < @id and AccountId = @abonent_id order by Id desc) +  (select top(1) In_balance from Balances where Id < @id and AccountId = @abonent_id order by Id desc);

if (@payment_last is null) select @payment_last = 0;

select @in_balance = @payment_last - @payment_summ;
if (@in_balance < 0) select @in_balance = 0;

update Balances set In_balance = @in_balance where Id = @id;
end