CREATE TABLE [dbo].[ElectricityBills](
	[Id] [uniqueidentifier] NOT NULL,
	[ConsumerNumber] [nvarchar](20) NOT NULL,
	[ElectricityProviderId] [uniqueidentifier] NOT NULL,
	CreatedById [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL
 CONSTRAINT [PK_ElectricityBills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ElectricityBills]  WITH CHECK ADD  CONSTRAINT [FK_ElectricityBills_ElectricityProviders] FOREIGN KEY([ElectricityProviderId])
REFERENCES [dbo].[ElectricityProviders] ([Id])
GO
ALTER TABLE [dbo].[ElectricityBills] CHECK CONSTRAINT [FK_ElectricityBills_ElectricityProviders]
GO
ALTER TABLE [dbo].ElectricityBills  WITH CHECK ADD  CONSTRAINT [FK_ElectricityBills_Users] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ElectricityBills] CHECK CONSTRAINT [FK_ElectricityBills_Users]
GO