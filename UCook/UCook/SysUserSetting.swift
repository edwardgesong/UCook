//
//  SysUserSetting.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-23.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation


public class SysUserSetting {
    
    public let Instance = SysConstants()
    
    init () {
    
    }
    
    
    static let defaults = NSUserDefaults.standardUserDefaults();
    

}
