USE [OrderManagement]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 07/22/2019 17:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[intOrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[vcName] [nvarchar](100) NULL,
	[intWeight] [int] NULL,
	[intHeight] [int] NULL,
	[vcImage] [nvarchar](max) NULL,
	[intStockKeepingUnits] [int] NULL,
	[vcBarcode] [nvarchar](max) NULL,
	[intAvailableQuantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[intOrderItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderItem] ON
INSERT [dbo].[OrderItem] ([intOrderItemID], [vcName], [intWeight], [intHeight], [vcImage], [intStockKeepingUnits], [vcBarcode], [intAvailableQuantity]) VALUES (1, N'Samsung Pro', 32, 30, NULL, 5, N'QWJUDGSHHSFVDS', 10)
INSERT [dbo].[OrderItem] ([intOrderItemID], [vcName], [intWeight], [intHeight], [vcImage], [intStockKeepingUnits], [vcBarcode], [intAvailableQuantity]) VALUES (2, N'Asus M1 Pro', 30, 25, NULL, 10, N'GFDGFGEWEDH', 8)
INSERT [dbo].[OrderItem] ([intOrderItemID], [vcName], [intWeight], [intHeight], [vcImage], [intStockKeepingUnits], [vcBarcode], [intAvailableQuantity]) VALUES (3, N'Samsung Pro', 150, 30, NULL, 3, N'EWQBVDGASH', 15)
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
/****** Object:  Table [dbo].[tbllookup]    Script Date: 07/22/2019 17:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbllookup](
	[intLookupID] [int] IDENTITY(1,1) NOT NULL,
	[vcLookupName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[intLookupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbllookup] ON
INSERT [dbo].[tbllookup] ([intLookupID], [vcLookupName]) VALUES (1, N'Approved')
INSERT [dbo].[tbllookup] ([intLookupID], [vcLookupName]) VALUES (2, N'Placed')
INSERT [dbo].[tbllookup] ([intLookupID], [vcLookupName]) VALUES (3, N'Cancelled')
INSERT [dbo].[tbllookup] ([intLookupID], [vcLookupName]) VALUES (4, N'In Delivery')
INSERT [dbo].[tbllookup] ([intLookupID], [vcLookupName]) VALUES (5, N'Completed')
SET IDENTITY_INSERT [dbo].[tbllookup] OFF
/****** Object:  Table [dbo].[Orders]    Script Date: 07/22/2019 17:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[intOrderID] [int] IDENTITY(1,1) NOT NULL,
	[vcBuyerName] [nvarchar](100) NULL,
	[vcBuyerPhone] [nvarchar](50) NULL,
	[vcBuyerEmail] [nvarchar](50) NULL,
	[vcShippingAddress] [nvarchar](max) NULL,
	[intOrderStatus] [int] NULL,
	[intOrderItem] [int] NULL,
	[intQuantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[intOrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT [dbo].[Orders] ([intOrderID], [vcBuyerName], [vcBuyerPhone], [vcBuyerEmail], [vcShippingAddress], [intOrderStatus], [intOrderItem], [intQuantity]) VALUES (3, N'Jesper', N'7326453252', N'jesper@yopmail.com', N'Denmark', 2, 1, 1)
INSERT [dbo].[Orders] ([intOrderID], [vcBuyerName], [vcBuyerPhone], [vcBuyerEmail], [vcShippingAddress], [intOrderStatus], [intOrderItem], [intQuantity]) VALUES (4, N'Kadir', N'6544515151', N'kadir@yopmail.com', N'Secunderabad', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
/****** Object:  StoredProcedure [dbo].[spUpsert_OrderItem]    Script Date: 07/22/2019 17:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Author: Harika                                            
---Date: 22nd July 2019                                                      
---Description: To upsert order item          
--exec spUpsert_Order  
CREATE PROCEDURE [dbo].[spUpsert_OrderItem]                                                       
(                                
@vcItemName nvarchar(100),  
@intWeight int,  
@intHeight int,  
@vcImage nvarchar(max),  
@intStockItems int,  
@vcBarCode nvarchar(max),  
@intAvailableQuantity int,  
@existOrderItemID int,  
@intOrderItemID INT OUTPUT  
)        
AS                                    
BEGIN                                    
BEGIN TRY                      
BEGIN TRANSACTION        
IF(@existOrderItemID = 0)    
  BEGIN      
     INSERT into Orderitem values(@vcItemName, @intWeight, @intHeight, @vcImage, @intStockItems, @vcBarCode, @intAvailableQuantity)  
     set @intOrderItemID = @@IDENTITY  
     Select @intOrderItemID  
  END  
ELSE  
   BEGIN  
     Update Orderitem set vcName=@vcItemName, intWeight=@intWeight, intHeight=@intHeight, vcImage=@vcImage,  
     intStockKeepingUnits=@intStockItems, vcBarcode= @vcBarCode, intAvailableQuantity=@intAvailableQuantity where intOrderItemID=@intOrderItemID 
   END    
COMMIT TRANSACTION                                   
END TRY                                    
BEGIN CATCH              
ROLLBACK TRANSACTION                          
DECLARE @ErrorMessage NVARCHAR(4000)=ERROR_MESSAGE()+' Please verify "'+ERROR_PROCEDURE()+'" stored procedure at the line number '+CONVERT(NVARCHAR(20),ERROR_LINE() )+ '.';                                    
DECLARE @ErrorSeverity INT = ERROR_SEVERITY();                                    
DECLARE @ErrorState INT=ERROR_STATE();                                    
RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState)                                    
END CATCH                                    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpsert_Order]    Script Date: 07/22/2019 17:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Author: Harika                                          
---Date: 22nd July 2019                                                    
---Description: To upsert order        
--exec spUpsert_Order
CREATE PROCEDURE [dbo].[spUpsert_Order]                                                     
(                              
@vcBuyerName nvarchar(100),
@vcBuyerPhone NVARCHAR(50),
@vcBuyerEmail nvarchar(50),
@vcShippingAddress nvarchar(max),
@intOrderStatus int,
@intOrderItem int,
@intQuantity int,
@existOrderID int,
@intOrderID INT OUTPUT
)      
AS                                  
BEGIN                                  
BEGIN TRY                    
BEGIN TRANSACTION      
IF(@existOrderID = 0)  
  BEGIN    
     INSERT into Orders values(@vcBuyerName, @vcBuyerPhone, @vcBuyerEmail, @vcShippingAddress, @intOrderStatus, @intOrderItem, @intQuantity)
     set @intOrderID = @@IDENTITY
     Select @intOrderID
  END
ELSE
   BEGIN
     Update Orders set vcBuyerName=@vcBuyerName, vcBuyerPhone=@vcBuyerPhone, vcBuyerEmail=@vcBuyerEmail, vcShippingAddress=@vcShippingAddress,
     intOrderStatus=@intOrderStatus, intOrderItem= @intOrderItem, intQuantity=@intQuantity where intOrderId=@existOrderID
   END  
COMMIT TRANSACTION                                 
END TRY                                  
BEGIN CATCH            
ROLLBACK TRANSACTION                        
DECLARE @ErrorMessage NVARCHAR(4000)=ERROR_MESSAGE()+' Please verify "'+ERROR_PROCEDURE()+'" stored procedure at the line number '+CONVERT(NVARCHAR(20),ERROR_LINE() )+ '.';                                  
DECLARE @ErrorSeverity INT = ERROR_SEVERITY();                                  
DECLARE @ErrorState INT=ERROR_STATE();                                  
RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState)                                  
END CATCH                                  
END
GO
/****** Object:  StoredProcedure [dbo].[spDisplay_Order]    Script Date: 07/22/2019 17:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Author: Harika                                          
---Date: 22nd July 2019                                                    
---Description: To display specific order
--exec spDisplay_Order
CREATE PROCEDURE [dbo].[spDisplay_Order]   
                                                  
@intOrderID int

AS                             
BEGIN                            
SET NOCOUNT ON;                            
  BEGIN TRY 
    select * from Orders where intOrderId=@intOrderID   
  END TRY          
            
  BEGIN CATCH          
   DECLARE @ErrorMessage NVARCHAR(4000)=ERROR_MESSAGE()+' Please verify "'+ERROR_PROCEDURE()+'" stored procedure at the line number '+CONVERT(NVARCHAR(20),ERROR_LINE() )+ '.';                            
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();                            
    DECLARE @ErrorState INT=ERROR_STATE();                           
    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState)                            
  END CATCH                            
END
GO
/****** Object:  StoredProcedure [dbo].[spDisplay_AllOrders]    Script Date: 07/22/2019 17:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Author: Harika                                          
---Date: 22nd July 2019                                                    
---Description: To display all orders
--exec spDisplay_AllOrders
CREATE PROCEDURE [dbo].[spDisplay_AllOrders]                                                     

AS                             
BEGIN                            
SET NOCOUNT ON;                            
  BEGIN TRY 
    select * from Orders      
  END TRY          
            
  BEGIN CATCH          
   DECLARE @ErrorMessage NVARCHAR(4000)=ERROR_MESSAGE()+' Please verify "'+ERROR_PROCEDURE()+'" stored procedure at the line number '+CONVERT(NVARCHAR(20),ERROR_LINE() )+ '.';                            
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();                            
    DECLARE @ErrorState INT=ERROR_STATE();                           
    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState)                            
  END CATCH                            
END
GO
/****** Object:  StoredProcedure [dbo].[spDelete_Order]    Script Date: 07/22/2019 17:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Author: Harika                                          
---Date: 22nd July 2019                                                    
---Description: To delete specific order
--exec spDelete_Order
CREATE PROCEDURE [dbo].[spDelete_Order]   
                                                  
@intOrderID int

AS                             
BEGIN                            
SET NOCOUNT ON;                            
  BEGIN TRY 
    Delete from Orders where intOrderId=@intOrderID   
  END TRY          
            
  BEGIN CATCH          
   DECLARE @ErrorMessage NVARCHAR(4000)=ERROR_MESSAGE()+' Please verify "'+ERROR_PROCEDURE()+'" stored procedure at the line number '+CONVERT(NVARCHAR(20),ERROR_LINE() )+ '.';                            
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();                            
    DECLARE @ErrorState INT=ERROR_STATE();                           
    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState)                            
  END CATCH                            
END
GO
/****** Object:  ForeignKey [FK__Orders__intOrder__108B795B]    Script Date: 07/22/2019 17:16:37 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([intOrderItem])
REFERENCES [dbo].[OrderItem] ([intOrderItemID])
GO
/****** Object:  ForeignKey [FK__Orders__intOrder__1367E606]    Script Date: 07/22/2019 17:16:37 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([intOrderStatus])
REFERENCES [dbo].[tbllookup] ([intLookupID])
GO
