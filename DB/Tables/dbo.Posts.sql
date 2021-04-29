CREATE TABLE [dbo].[Posts]
(
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Content] [varchar](1000) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Posts] ADD CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY]
GO