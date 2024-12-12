USE [TRWalksDb]
GO

DELETE FROM [TRWalksDb].[dbo].[Regions];
DELETE FROM [TRWalksDb].[dbo].[Difficulties];
DELETE FROM [TRWalksDb].[dbo].[Walks];
GO

INSERT [dbo].[Difficulties] ([Id], [Name]) VALUES 
(N'7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', N'Easy'),
(N'3c2a7fdd-22b8-4b39-9b9d-4b929ecdd9fc', N'Medium'),
(N'1a1f1f7a-c8c5-4b5b-9e8d-70897bfc1c71', N'Hard');
GO

INSERT [dbo].[Regions] ([Id], [Code], [Name], [RegionImageUrl]) VALUES 
(N'd8f8177a-a123-4e5d-9b67-8b08a72f6ef3', N'TMS', N'Tomsk City', N'https://example.com/images/tomsk_city.jpg'),
(N'2b81c778-2fc5-4a44-a488-d771f58999f5', N'OBR', N'Ob River', N'https://example.com/images/ob_river.jpg'),
(N'96ccf99b-f8c6-4b6a-b234-48d4a0fbe4e1', N'VNZ', N'Voskresensk Hill', NULL),
(N'b781f2a5-4468-4f4a-a8b3-f1a889f238d7', N'SCB', N'Siberian Botanical Garden', NULL),
(N'e23a9d37-a982-41a5-8723-c571d0199bff', N'LNI', N'Lagerny Garden', NULL),
(N'a1d4e987-2af2-4e34-812d-50445cc02bb1', N'SPL', N'Spaso-Preobrazhensky Cathedral', N'https://example.com/images/cathedral.jpg');
GO

INSERT INTO [TRWalksDb].[dbo].[Walks] 
(Id, Name, Description, LengthInKm, WalkImageUrl, DifficultyId, RegionId) VALUES 
('b2a8179b-8e5b-491a-9b1c-408f423dd7f2', 'Tomsk Historical Walk', 'Explore the historical streets of Tomsk with unique wooden architecture.', 3.2, 'https://example.com/images/tomsk_history.jpg', '7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', 'd8f8177a-a123-4e5d-9b67-8b08a72f6ef3'),
('cc67e7ab-72e6-4cfa-92cb-8d117af839a5', 'Ob River Promenade', 'A scenic walk along the Ob River with stunning sunset views.', 5.5, 'https://example.com/images/ob_promenade.jpg', '3c2a7fdd-22b8-4b39-9b9d-4b929ecdd9fc', '2b81c778-2fc5-4a44-a488-d771f58999f5'),
('f32b8d1e-9a67-4a7a-8f1d-b8db5f2f1cb7', 'Voskresensk Hill Hike', 'A challenging hike up Voskresensk Hill for panoramic city views.', 4.8, 'https://example.com/images/voskresensk_hill.jpg', '1a1f1f7a-c8c5-4b5b-9e8d-70897bfc1c71', '96ccf99b-f8c6-4b6a-b234-48d4a0fbe4e1'),
('a9f5c37a-bc34-4c9f-b23b-df6e92c0a9cb', 'Siberian Botanical Garden Trail', 'Discover the diverse flora of the Siberian Botanical Garden.', 2.0, 'https://example.com/images/botanical_garden.jpg', '7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', 'b781f2a5-4468-4f4a-a8b3-f1a889f238d7'),
('d89f1b8c-64af-4a2f-9e9e-c9c7a7f1f9c8', 'Lagerny Garden Stroll', 'Enjoy the serene environment and picturesque scenery of Lagerny Garden.', 3.0, NULL, '3c2a7fdd-22b8-4b39-9b9d-4b929ecdd9fc', 'e23a9d37-a982-41a5-8723-c571d0199bff'),
('c47b19b4-fc92-4a5e-a89c-d991f27d37f1', 'Cathedral Walk', 'A peaceful walk around Spaso-Preobrazhensky Cathedral and its surroundings.', 1.5, 'https://example.com/images/cathedral_walk.jpg', '7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', 'a1d4e987-2af2-4e34-812d-50445cc02bb1'),
('d71b2c88-1b84-46a7-930f-b47c3e77f768', 'University Grove Path', 'Walk through the scenic university grove.', 3.7, NULL, '7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', 'b781f2a5-4468-4f4a-a8b3-f1a889f238d7'),
('b3c28d91-986c-4f94-b8b7-94720f0d6a3f', 'Art Street Tour', 'Explore the vibrant art scene in the city.', 2.3, 'https://example.com/images/art_street.jpg', '3c2a7fdd-22b8-4b39-9b9d-4b929ecdd9fc', 'd8f8177a-a123-4e5d-9b67-8b08a72f6ef3'),
('e4c9b084-9a58-4501-a6b8-8d11ffefc9a2', 'River Island Excursion', 'Discover the small islands in the river.', 4.0, NULL, '1a1f1f7a-c8c5-4b5b-9e8d-70897bfc1c71', '2b81c778-2fc5-4a44-a488-d771f58999f5'),
('c2398f07-0eb3-43b8-94ad-b3819c8e3e7c', 'Winter Festival Walk', 'Experience the festive decorations and winter charm.', 1.8, NULL, '7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', 'e23a9d37-a982-41a5-8723-c571d0199bff'),
('b56d4a98-9a9b-4b6d-800f-b27f6b3c9e7e', 'Forest Adventure', 'Embark on a forest trail adventure.', 5.2, NULL, '1a1f1f7a-c8c5-4b5b-9e8d-70897bfc1c71', 'b781f2a5-4468-4f4a-a8b3-f1a889f238d7'),
('e7d8b29b-0c3e-4948-87df-b72b6f9c6e4e', 'Sunrise Lake Walk', 'Enjoy a peaceful morning at the lake.', 3.1, 'https://example.com/images/sunrise_lake.jpg', '3c2a7fdd-22b8-4b39-9b9d-4b929ecdd9fc', '96ccf99b-f8c6-4b6a-b234-48d4a0fbe4e1'),
('d98b7f84-6b3d-476a-b76b-c78f8c9b4e2d', 'City Park Loop', 'A refreshing walk through the city park.', 2.5, NULL, '7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', 'a1d4e987-2af2-4e34-812d-50445cc02bb1'),
('f98c2d75-7c4d-487b-8f8c-c81a9d3b2f8d', 'Evening Lights Tour', 'Witness the beauty of the city lights in the evening.', 2.9, 'https://example.com/images/evening_lights.jpg', '3c2a7fdd-22b8-4b39-9b9d-4b929ecdd9fc', 'd8f8177a-a123-4e5d-9b67-8b08a72f6ef3'),
('b89e7f92-8e5d-4a76-879b-c92f6d8f8a9e', 'Hillside Exploration', 'Climb and explore the hillside paths.', 4.3, 'https://example.com/images/hillside.jpg', '1a1f1f7a-c8c5-4b5b-9e8d-70897bfc1c71', '96ccf99b-f8c6-4b6a-b234-48d4a0fbe4e1'),
('a123d456-7e8f-491a-9b1c-508f623de8f3', 'Tomsk State University Trail', 'Explore the beautiful and historic campus of Tomsk State University.', 2.7, 'https://example.com/images/tsu_trail.jpg', '7e5a7bb9-523e-4b09-8b4f-7fa109d111a3', 'b781f2a5-4468-4f4a-a8b3-f1a889f238d7');
GO

