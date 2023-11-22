SELECT TOP (1000) [Id]
      ,[Title]
      ,[Publisher]
   ,[ReleaseYear]
  FROM [VideoGameDb].[dbo].[VideoGames]

-- INSERT INTO [VideoGameDb].[dbo].[VideoGames] (Title, Publisher, ReleaseYear)
--     VALUES ('Tetris', 'Atari', 1989);

INSERT INTO [VideoGameDb].[dbo].[VideoGames] (Title, Publisher, ReleaseYear)
     VALUES ('Space Invaders', 'Taito Corporation', 1978);