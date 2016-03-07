-- INSERT INTO `portraitdev`.`productcategories`
-- (`Name`)
-- VALUES
-- ( 'Portrait');
-- INSERT INTO `portraitdev`.`productcategories`
-- (`Name`)
-- VALUES
-- ( 'Größe');
-- INSERT INTO `portraitdev`.`productcategories`
-- (`Name`)
-- VALUES
-- ( 'Person oder Subject');

-- INSERT INTO `portraitdev`.`products`
-- (`Name`, `Price`, `ProductCategoryId`)
-- VALUES
-- ( 'Person oder Subject', 20, 3);
-- 
-- 
-- INSERT INTO `portraitdev`.`products`
-- (`Name`, `Price`, `ProductCategoryId`)
-- VALUES
-- ( 'A4', 0, 2);
-- 
-- 
-- INSERT INTO `portraitdev`.`products`
-- (`Name`, `Price`, `ProductCategoryId`)
-- VALUES
-- ( 'A3', 30, 2);
-- 
-- 
-- INSERT INTO `portraitdev`.`products`
-- (`Name`, `Price`, `ProductCategoryId`)
-- VALUES
-- ( 'A2', 60, 2);
-- 
-- INSERT INTO `portraitdev`.`PriceAdjustments`
-- (`Name`, `Adjustment`)
-- VALUES
-- ( 'Erste Person oder Subjekt inkl.', -20);
-- 
INSERT INTO `portraitdev`.`PriceAdjustmentProducts`
 (`PriceAdjustment_Id`, `Product_Id`)
VALUES
 ( 1, 4);