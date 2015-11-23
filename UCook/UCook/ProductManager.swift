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
        self.allProductList = []
    }
    
    
    private var allProductList : [Product]
    
    
    private func AddProductToList (product: Product?) -> Void {
        if let product = product {
           allProductList.append(product)
        } else {
            return
        }
    }
    
    
    private func RemoveProductFromList (product: Product) -> Void {
        
    }
    
}
