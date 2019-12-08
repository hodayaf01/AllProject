alter table [dbo].[MedicinesToChild]
	add CONSTRAINT fk_KingOfDosage FOREIGN KEY ([Dosage])
	REFERENCES [dbo].[KingOfDosage]([kindOfDosageId])

alter table [dbo].[MedicinesToChild]
	add CONSTRAINT fk_medicineId FOREIGN KEY ([medicineId])
	REFERENCES [dbo].[Medicines] ([medicineId])

	alter table [dbo].[MedicinesToChild]
	add CONSTRAINT fk_childId FOREIGN KEY ([childId])
	REFERENCES [dbo].[Users] ([Id])

	alter table [dbo].[Users]
	add CONSTRAINT fk_userHMO FOREIGN KEY ([userHMO])
	REFERENCES [dbo].[HMO] ([IdHMO])

	alter table [dbo].[guardiansToUser]
	add CONSTRAINT fk_userId FOREIGN KEY ([userId])
	REFERENCES [dbo].[Users] ([Id])

	alter table [dbo].[guardiansToUser]
	add CONSTRAINT fk_guardianId FOREIGN KEY ([guardianId])
	REFERENCES [dbo].[Guardian] ([Id])

	--alter table [dbo].[MedicinesToChild]
	--add CONSTRAINT fk_timeOfDay FOREIGN KEY ([timeOfDay])
	--REFERENCES [dbo].[TimeOfDay] ([timeId])

	alter table [dbo].[TimeToMedicinesForChild]
	add CONSTRAINT fk_timeOfDay FOREIGN KEY ([idTimeOfDay])
	REFERENCES [dbo].[TimeOfDay] ([timeId])
	
	alter table [dbo].[TimeToMedicinesForChild]
	add CONSTRAINT fk_MedicineToChild FOREIGN KEY ([idMedicineToChild])
	REFERENCES [dbo].[MedicinesToChild] ([Id])

	ALTER TABLE [dbo].[MedicinesToChild]
	DROP CONSTRAINT fk_timeOfDay