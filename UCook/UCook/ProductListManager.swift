//
//  ProductManager.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-22.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation


public class ProductListManager {
    
    static let Instance = ProductListManager ()
    
    init () {
        self.allProductList = Array<ProductModel> ()
    }
    
    
    private(set) var allProductList : Array<ProductModel>
    
    
    /**
     Add a single product to the end of allProductList
     - returns: Void
     - parameter product: Product?
     */
    public func AddProductToList (product: ProductModel!) -> Void {
        if let product = product {
           allProductList.append(product)
        } else {
            debugPrint("[Error] : Trying to add a nil product")
            return
        }
    }
    
    
    /**
     Remove a single product from allProductList
     - returns: Void
     - parameter product: Product
     */
    public func RemoveProductFromList (product: ProductModel?) -> Void {
        if let product = product {
            if allProductList.count != 0 {
                if let indexOfProduct = allProductList.indexOf({$0 === product}) {
                        allProductList.removeAtIndex(indexOfProduct)
                } else {
                    debugPrint("[Error] : Trying to remove product does not exist")
                    return
                }
            }
        } else {
            debugPrint("[Error] : Trying to remove a nill product")
            return
        }
    }
    
    
    /**
     Remove all products from allProductList
     - returns: Void
     */
    public func ClearAllProductList () -> Void {
        allProductList = Array<ProductModel> ()
    }
    
    
    /**
    Get a list of products by difficulty level
    - returns: Array<Product>?
    - parameter level: Int
    */
    public func GetProductListByLevel (level : Int) -> Array<ProductModel>? {
        var products : Array<ProductModel>?
        
        products = allProductList.filter({$0.difficultyLevel == level})
        
        return products
    }
    
    
    /**
     Get the product by product id
     - returns: Product?
     - parameter id: Int
     */
    public func GetProductById (id : Int) -> ProductModel? {
        var product : ProductModel?
        
        if let indexOfProduct = allProductList.indexOf({$0.id == id}) {
            product = allProductList[indexOfProduct]
        }
        
        return product
    }
    
    
    /**
     Get the product by cuisine
     - returns: Array<Product>?
     - parameter cuisine: Int
     */
    public func GetProductByCuisine (cuisine_id: Int) -> Array<ProductModel>? {
        var products : Array<ProductModel>?
        
        products = allProductList.filter({$0.cuisineId == cuisine_id})
        
        return products
    }
    
    
    /**
     Get the product by classification
     - returns: Array<Product>?
     - parameter class_id: Int
     */
    public func GetProductByClass (class_id: Int) -> Array<ProductModel>? {
        var products : Array<ProductModel>?
        
        products = allProductList.filter({$0.classsificationId == class_id})
        
        return products
    }
    
    
}
