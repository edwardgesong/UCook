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
        GetMaterialList(_model?.material)
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
            if let model = model {
                model.cuisine_id = newValue
            }
        }
    }
    
    
    public var classsificationId : Int? {
        get {
            if let model = model {
                return model.classification_id
            } else {
                return nil
            }
        }
        set {
            if let model = model {
                model.classification_id = newValue
            }
        }
    }
    
    
    public var description : String? {
        get {
            if let model = model {
                return model.desc
            } else {
                return nil
            }
        }
        set {
            if let model = model {
                model.desc = newValue
            }
        }
    }
    
    
    public var difficultyLevel : Int? {
        get {
            if let model = model {
                return model.difficulty_level
            } else {
                return nil
            }
        }
        set {
            if let model = model {
                model.difficulty_level = newValue
            }
        }
    }
    
    
    public var materialId : [Int]? {
        get {
            if let model = model {
                return model.material
            } else {
                return nil
            }
        }
        set {
            if let model = model {
                model.material = newValue
            }
        }
    }
    
    
    public var materials : [Material]?

    
    public var cookStep : [Step]? {
        get {
            if let model = model {
                return model.step
            } else {
                return nil
            }
        }
        set {
            if let model = model {
                model.step = newValue
            }
        }
    }
    
    
    
    //Functions - Private
    
    
    private func GetMaterialList (materialId : [Int]?) -> [Material]? {
        
        var result : [Material]? = nil
        
        if let materialId = materialId {
            result = MaterialManager.GetMaterialListFromLocal(materialId);
        } else {
            debugPrint("[Error] : Trying To Get Material List With Null Id List");
        }
        
        return result
    }
    
}
