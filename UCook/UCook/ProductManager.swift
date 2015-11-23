//
//  ProductManager.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-22.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation


public class ProductManager {
    
    static let Instance = ProductManager ()
    
    
    init (){
        self.allProductList = Array<Product> ()
    }
    
    
    private(set) var allProductList : Array<Product>
    
    
    /**
     Add a single product to the end of allProductList
     - returns: Void
     - parameter product: Product?
     */
    public func AddProductToList (product: Product!) -> Void {
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
    public func RemoveProductFromList (product: Product?) -> Void {
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
        allProductList = Array<Product> ()
    }
    
    
    /**
    Get a list of products by difficulty level
    - returns: Array<Product>?
    - parameter level: Int
    */
    public func GetProductListByLevel (level : Int) -> Array<Product>? {
        var products : Array<Product>?
        
        products = allProductList.filter({$0.difficulty_level == level})
        
        return products
    }
    
    
    /**
     Get the product by product id
     - returns: Product?
     - parameter id: Int
     */
    public func GetProductById (id : Int) -> Product? {
        var product : Product?
        
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
    public func GetProductByCuisine (cuisine_id: Int) -> Array<Product>? {
        var products : Array<Product>?
        
        products = allProductList.filter({$0.cuisine_id == cuisine_id})
        
        return products
    }
    
    
    /**
     Get the product by classification
     - returns: Array<Product>?
     - parameter class_id: Int
     */
    public func GetProductByClass (class_id: Int) -> Array<Product>? {
        var products : Array<Product>?
        
        products = allProductList.filter({$0.classification_id == class_id})
        
        return products
    }
    
    
}
