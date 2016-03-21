CREATE TABLE [dbo].[Produto] (
    [ProdutoId] [int] NOT NULL IDENTITY,
    [Nome] [varchar](100) NOT NULL,
    [Preco] [decimal](18, 2) NOT NULL,
    [Estoque] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Produto] PRIMARY KEY ([ProdutoId])
)
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201603201939350_AutomaticMigration', N'ADOWebAppMVC.Migrations.Configuration',  0x1F8B0800000000000400CD57C96EE34610BD07C83F34FAEC51CBF66562503350242B1032B28CA1C739B7C892DC482F1C76D3B0BE2D87F9A4FC42AAB98BD4E65930812E62B3EA55D5ABADF9EF3F5F82F72F4A926748AD307A442F07434A404726167A33A2995BBF794BDFBFFBF597E036562FE4B192BBF672A8A9ED883E3997DC3066A32750DC0E94885263CDDA0D22A3188F0DBB1A0E7F6397970C1082221621C1C74C3BA1207FC0C789D111242EE372616290B63CC737618E4AEEB8029BF00846743C5DFE05AB71922C1E27035474F0E228194BC1D19710E49A12AEB571DCA1A7379F2C842E357A132678C0E5C33601945B7369A18CE0A6113F3798E1950F86358A1554945967D42B012FAF4B765857FDAB38A6357BC8DF2DF2ECB63EEA9CC311BD4F4D9C394349D7D6CD44A65EAEC370919041A97641DA2F2FEA82C0BAF1BF0B32C9A4CB521869C85CCAE505B9CF5652447FC2F6C1FC0D7AA43329DB0EA28BF86EE7008FD05A02A9DB7E84F5AEDBF39812B6ABCEBAFAB5765FB5886FAEDDF5152577E80A5F49A8ABA1C545E84C0A7F8086943B88EFB973906232E731E47CF69CE898BC330A2A6B587ED84B942CF8CB07D01BF7845D36C4EE99891788AB93D2834F5A60EBA1924B33D8E3E171ABF72944A6323B8548282E29F1A7A2ECEEB7948411F780FBE23F8E7E8BE5F239835324B64102D6945FBF287DEF7281145706667537F76A13DBB82C4F5B92B3EB6B811882DBCDB9A5A4F1A0980E83BA01F6795AFBD44C20568CA06A54B103B32A58F024C144B766577942C262704DDE84AFEF675560B0C8EE69EBDADBDA12962DDF40E72D9A464F6722B56ECA1D5F719FA749AC7A624D060EB05BD9E990DC6DDF86F34AC1FF2F94F68DEF3A271DA086C31986A5B0F7F208A1F6A719673DCD7C7770C9D3C3D3606264A6F489F9720CAB68F3364C71723E42D9B2BB9EE447E763D48DD946A90FFB3801EB90DA4D1FEBE5AF3371BBF570AC91BA22B5F5BAA13A8D1394457CFA26D0ABEA42C48F3CF32C625FD1E1D63A50032F30083FCB8914186F23B0E05AACC1BA6237515CC5579DABC4FF67AD336B6379DE6EFFC9FB55788A4F6ED057AE9FF64A7DE669F4C4D3FE4EFD968519FFE08599B3F21DD7657FA69FB5128F6DC4A27F908A9567A5F0F35BD765BF9B03D6BEFD0753B062D340F86F010D916F9306B49299EBB5A958C6C8DA1E55229D242CC0F118091AA74EAC79E4F07504D6E637B2472E339F27B58278AE97994B3237B616D44AEEDCF00276DC7E7E27D8F5395826FEC97E8F10D04D8121C052FF9E0919D77ECFF654D001085F2B652FA257782345B8CDB646BA33FA4CA092BE2924A07D273F804A2482D9A50EF9337C8D6F78B5FB001B1E6DABA17C18E4742276690FA6826F52AE6C89D1E8FB2F5AE63F69DFFD074004628B040F0000 , N'6.1.3-40302')
