﻿CREATE TABLE [dbo].[MobileRechargeBills](
	[Id] [uniqueidentifier] NOT NULL,
	[ServiceProviderId] [uniqueidentifier] NOT NULL,
	[MobileRechargeTypeId] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[LastUpdatedOn] [datetimeoffset](7) NULL,
	[RemovedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_MobileRechargeBills_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MobileRechargeBills]  WITH CHECK ADD  CONSTRAINT [FK_MobileRechargeBills_MobileRechargeTypes] FOREIGN KEY([MobileRechargeTypeId])
REFERENCES [dbo].[MobileRechargeTypes] ([Id])
GO
ALTER TABLE [dbo].[MobileRechargeBills] CHECK CONSTRAINT [FK_MobileRechargeBills_MobileRechargeTypes]
GO
ALTER TABLE [dbo].[MobileRechargeBills]  WITH CHECK ADD  CONSTRAINT [FK_MobileRechargeBills_MobileRechargeTypes1] FOREIGN KEY([MobileRechargeTypeId])
REFERENCES [dbo].[MobileRechargeTypes] ([Id])
GO
ALTER TABLE [dbo].[MobileRechargeBills] CHECK CONSTRAINT [FK_MobileRechargeBills_MobileRechargeTypes1]
GO