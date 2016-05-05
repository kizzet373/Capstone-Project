use [AnatoknightStudiosTests]

DELETE FROM  Comment DBCC CHECKIDENT (Comment, RESEED, 1)
DELETE FROM  Post_Tag
DELETE FROM  PostImageUrls
DELETE FROM  Tag DBCC CHECKIDENT (Tag, RESEED, 1)
DELETE FROM  StaticPage DBCC CHECKIDENT (StaticPage, RESEED, 1)
DELETE FROM  Post DBCC CHECKIDENT (Post, RESEED, 1)
DELETE FROM  Category DBCC CHECKIDENT (Category, RESEED, 1)
DELETE FROM  Blog DBCC CHECKIDENT (Blog, RESEED, 1)
DELETE FROM  dbo.AspNetUserClaims DBCC CHECKIDENT(AspNetUserClaims, RESEED,1)
DELETE FROM  dbo.AspNetUserLogins
DELETE FROM  dbo.AspNetUserRoles
DELETE FROM  dbo.AspNetUsers 
DELETE FROM  dbo.AspNetRoles 
Delete From __MigrationHistory


