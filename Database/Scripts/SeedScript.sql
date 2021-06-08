
--Users
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [EmailId], [Password], [IsActivated], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES 
(N'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', N'Sumit', N'Mahajan', N'msumit35', N'msumit35@gmail.com', 
N'Q0Ew/2K7VKzAVG7DLomjSUfJjjvaexqD8X/90mqvZPM=', 1, 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

--ElectricityProviders
INSERT INTO ElectricityProviders ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('D8671FC5-C665-4E43-AB0E-18C194FFCCCB', 'Mahavitaran Ltd.', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

INSERT INTO ElectricityProviders ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('887342AF-5007-4429-8F4C-A518F59E4585', 'Reliance Ltd.', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

INSERT INTO ElectricityProviders ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('E40E58F1-8105-4775-A838-CE1F50B62E8A', 'Airtel Electricity Ltd.', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

--MobileRechargeTypes
INSERT INTO MobileRechargeTypes ([Id], [Name])
VALUES ('EBB30C95-D306-4565-B4F6-C38CA3DFAC8F', 'Prepaid')

INSERT INTO MobileRechargeTypes ([Id], [Name])
VALUES ('35AD39D1-428E-4DDA-9DA7-DF2396B8F965', 'Postpaid')

--PaymentModes
INSERT INTO PaymentModes ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('DF7D0203-444C-4131-A5F7-3076FD894C34', 'Credit/Debit Card', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

INSERT INTO PaymentModes ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('4914F946-84DC-4F4C-9AFE-E8EC6B74A7E8', 'UPI', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

--PaymentStatuses
INSERT INTO PaymentStatuses ([Id], [Name])
VALUES ('0F028152-43BB-4DCE-8F15-59CDE17C4CF9', 'Success')

INSERT INTO PaymentStatuses ([Id], [Name])
VALUES ('43329146-B1F5-4231-8EC9-9697A57B9921', 'Failed')

--ServiceProviders
INSERT INTO ServiceProviders ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('D11F60EB-3398-4B01-9A54-9B3DDDA301DA', 'Airtel', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

INSERT INTO ServiceProviders ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('78A61FF0-935D-4DE6-AD2F-66087DD17CEB', 'Vodafone', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

INSERT INTO ServiceProviders ([Id], [Name], [CreatedById], [CreatedOn], [LastUpdatedOn], [RemovedOn])
VALUES ('2EAE9928-C9FC-47AE-8322-80B1CA2D586C', 'Jio', 'ab3c1a56-50bf-4aad-a481-49ab73e3bcee', CAST(N'2020-03-23T23:34:56.3622943+05:30' AS DateTimeOffset), NULL, NULL)

