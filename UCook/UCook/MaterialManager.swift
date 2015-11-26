//
//  MaterialManager.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-25.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation


public class MaterialManager {

    static let Instance = MaterialManager ()
    
    init () {
    
    }
    
    static func GetMaterialListFromLocal (materialId : [Int]) -> [Material]? {
        
        var result : [Material]?
        
        // TODO : Fetch List Of Materials From Local DB
        
        return result
    }
}
