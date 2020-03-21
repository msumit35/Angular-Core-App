CREATE TABLE [dbo].[ExceptionLogs](
	[Id] [uniqueidentifier] NOT NULL,
	[Controller] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[StackTrace] [nvarchar](max) NULL,
	[LogTime] [datetimeoffset](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO