//
//  BackTableVC.swift
//  UCook
//
//  Created by Yuan Lu on 2015-12-21.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation


class BackTableViewController: UITableViewController {
    
    var TableArray = [String] ()
    
    override func viewDidLoad() {
        TableArray = ["Menu", "Level", "Login"]
    }
    
    override func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return TableArray.count
    }
    
    override func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        var cell = tableView.dequeueReusableCellWithIdentifier("cell", forIndexPath: indexPath) as UITableViewCell
        
        cell.textLabel?.text = TableArray[indexPath.row]
        
        return cell
    }
    
    
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        var DestViewController = segue.destinationViewController as! ProductViewController
        
        var indexPath : NSIndexPath = self.tableView.indexPathForSelectedRow!
        
        DestViewController.varView = indexPath.row
    }
}