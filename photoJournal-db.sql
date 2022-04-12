USE [master]
GO
IF db_id('photoJournal') IS NULL
  CREATE DATABASE [photoJournal]
GO
USE [photoJournal]
GO

DROP TABLE IF EXISTS [Comments];
DROP TABLE IF EXISTS [Threads];
DROP TABLE IF EXISTS [JournalPost];
DROP TABLE IF EXISTS [Users];

CREATE TABLE [Users] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [FullName] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [ProfileImage] nvarchar(255) NOT NULL,
  [IsAdmin] BIT
)
GO

CREATE TABLE [Threads] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [UserId] integer NOT NULL,
  [JournalId] integer NOT NULL,
  [Title] nvarchar(255) NOT NULL,
  [Content] nvarchar(255) NOT NULL,
  [CreateDateTime] datetime NOT NULL
)
GO

CREATE TABLE [JournalPost] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [UserId] integer NOT NULL,
  [Title] nvarchar(255) NOT NULL,
  [Content] nvarchar(255) NOT NULL,
  [imageLocation] nvarchar(255) NOT NULL,
  [CreateDateTime] datetime NOT NULL
)
GO

CREATE TABLE [Comments] (
  [id] integer PRIMARY KEY identity NOT NULL,
  [ThreadId] integer NOT NULL,
  [UserId] integer NOT NULL,
  [Content] nvarchar(255) NOT NULL,
  [CreateDateTime] datetime NOT NULL
)
GO

ALTER TABLE [JournalPost] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO
ALTER TABLE [Threads] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO
ALTER TABLE [Threads] ADD FOREIGN KEY ([JournalId]) REFERENCES [JournalPost] ([Id])
GO
ALTER TABLE [Comments] ADD FOREIGN KEY ([ThreadId]) REFERENCES [Threads] ([Id])
GO
ALTER TABLE [Comments] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

SET IDENTITY_INSERT [Users] ON
INSERT INTO [Users]
  ([Id], [FullName], [Email], [ProfileImage], [IsAdmin])
VALUES 
  (1, 'Oliver Hardy', 'olive@gmail.com', '', 1);
SET IDENTITY_INSERT [Users] OFF

  SET IDENTITY_INSERT [JournalPost] ON
INSERT INTO [JournalPost]
  ([Id], [UserId], [Title], [Content], [imageLocation], [CreateDateTime])
VALUES 
  (1, 1, 'This is a journal', 'This journal is contains text and photos', '', '04-22-2020');
  SET IDENTITY_INSERT [JournalPost] OFF

SET IDENTITY_INSERT [Threads] ON
INSERT INTO [Threads]
  ([Id], [UserId], [JournalId], [Title], [Content], [CreateDateTime])
VALUES 
  (1, 1, 1, 'This is a thread', 'Use this thread to start a conversation', '04-20-2020');
  SET IDENTITY_INSERT [Threads] OFF

SET IDENTITY_INSERT [Comments] ON
INSERT INTO [Comments]
  ([Id], [ThreadId], [UserId], [Content], [CreateDateTime])
VALUES 
  (1, 1, 1, 'This is the first comment', '04-21-2020');
  SET IDENTITY_INSERT [Comments] OFF
