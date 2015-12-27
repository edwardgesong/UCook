//
//  ProductViewController.swift
//  UCook
//
//  Created by Yuan Lu on 2015-12-20.
//  Copyright © 2015 PANDA. All rights reserved.
//

import UIKit

class ProductViewController : UIViewController {
    
    @IBOutlet weak var Label: UILabel!
    @IBOutlet weak var Open: UIBarButtonItem!
    
    var varView = Int()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
//        Open.target = self.revealViewController()
//        Open.action = Selector ("revealToggle:")
        
        self.view.addGestureRecognizer(self.revealViewController().panGestureRecognizer())
        
        if (varView == 0) {
            Label.text = "Strings"
        } else {
            Label.text = "Others"
        }
    }
}