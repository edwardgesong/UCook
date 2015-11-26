//
//  ProductModel.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-25.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation


public class ProductModel {
    
    init (product : Product?) {
        _model = product
    }
    
    private var _model : Product?
    public var model : Product? {
        get {
            return _model
        }
        set {
            _model = newValue
        }
    }
    
    
    //Variables
    
    public var cuisineId : Int? {
        get {
            if let model = model {
                return model.cuisine_id
            } else {
                return nil
            }
        }
        set {
            if let model = model{
                model.cuisine_id = newValue
            }
        }
    }
    
    
    
    public var classsificationId : Int? {
        get {
            if let model = model {}
        }
    }
    
}
