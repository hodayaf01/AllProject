select * from Users;

alter table Users
add points int;

alter table Users
add snoozeCounter int;

alter table Users
add snoozePariod int;

select * from MedicinesToChild;

alter table MedicinesToChild
drop COLUMN  status

alter table MedicinesToChild
add status bit;

