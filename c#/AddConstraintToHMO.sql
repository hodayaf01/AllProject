alter table [dbo].[MedicinesToClient]
	add CONSTRAINT fk_KingOfDosage FOREIGN KEY ([Dosage])
	REFERENCES [dbo].[KingOfDosage]([kindOfDosageId])

alter table [dbo].[MedicinesToClient]
	add CONSTRAINT fk_medicineId FOREIGN KEY ([medicineId])
	REFERENCES [dbo].[Medicines]([medicineId])

	alter table [dbo].[MedicinesToClient]
	add CONSTRAINT fk_clientId FOREIGN KEY ([clientId])
	REFERENCES  [dbo].[Clients] ([Id])

	alter table [dbo].[Clients]
	add CONSTRAINT fk_clientHMO FOREIGN KEY ([clientHMO])
	REFERENCES [dbo].[HMO] ([IdHMO])

	alter table [dbo].[TimeMedicinesToClient]
	add CONSTRAINT fk_TimeMedicines FOREIGN KEY ([timeOfDayId])
	REFERENCES [dbo].[TimeOfDay] ([timeId])

	alter table [dbo].[MedicinesToClient]
	add CONSTRAINT fk_timeOfDay FOREIGN KEY ([timeOfDay])
	REFERENCES [dbo].[TimeOfDay] ([timeId])

	ALTER TABLE [dbo].[TimeMedicinesToClient]
	DROP CONSTRAINT fk_TimeMedicines
	-----------
	ALTER TABLE [dbo].[MedicinesToClient]
	DROP CONSTRAINT fk_timeOfDay

	alter table [dbo].[TimeToMedicinesForClient]
	add CONSTRAINT fk_timeOfDay FOREIGN KEY ([idTimeOfDay])
	REFERENCES [dbo].[TimeOfDay] ([timeId])
	
	alter table [dbo].[TimeToMedicinesForClient]
	add CONSTRAINT fk_MedicineToChild FOREIGN KEY ([idMedicineToClient])
	REFERENCES [dbo].[MedicinesToClient] ([Id])

	