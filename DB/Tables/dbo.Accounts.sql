CREATE TABLE [dbo].[Accounts]
(
[Id] [uniqueidentifier] NOT NULL,
[RoleId] [int] NOT NULL,
[Email] [nvarchar] (50) NOT NULL,
[FullName] [nvarchar] (50) NOT NULL,
[PasswordHash] [nvarchar] (100) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts] ADD CONSTRAINT [PK_Accounts] PRIMARY KEY ([Id]) ON [PRIMARY]
GO
