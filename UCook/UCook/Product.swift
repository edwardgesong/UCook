//
//  Product.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-20.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation


public class Product : Base {
    
    public var cuisine : Int?
    
    public var classification : Int?
    
    public var desc : String?
    
    public var difficulty_level : Int?

    public var material : [Int]?
    
    public var step : [Step]?

}