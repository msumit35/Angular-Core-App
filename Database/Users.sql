CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[EmailId] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[LastUpdatedOn] [datetimeoffset](7) NULL,
	[RemovedOn] [datetimeoffset](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO