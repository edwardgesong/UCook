//
//  HttpRequest.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-21.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation



public class HttpRequest {
    
    public func HttpPostRequest (body: AnyObject, urlStr: String) -> AnyObject? {
        
        var responseCode: AnyObject?
        
        let request = NSMutableURLRequest (URL: NSURL(string: SysConstants.Base_Url + urlStr)!)
        let session = NSURLSession.sharedSession()
        request.HTTPMethod = "POST"
        
        request.HTTPBody = try! NSJSONSerialization.dataWithJSONObject(body, options: [])
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        request.addValue("application/json", forHTTPHeaderField: "Accept")
        
        let task = session.dataTaskWithRequest(request) {data, response, error in guard data != nil else {
                print("[Error] HttpRequest: \(error)")
                return
            }
            
            do {
                if let json = try NSJSONSerialization.JSONObjectWithData(data!, options: []) as? NSDictionary {
                    let success = json["success"] as? Int
                    
                    responseCode = data!.valueForKey("code")
                    print("Success: \(success)")
                } else {
                    let jsonStr = NSString (data: data!, encoding: NSUTF8StringEncoding)
                    print("[Error] Deserialize Json: \(jsonStr)")
                }
            } catch let parseError {
                print(parseError)
                
                let jsonStr = NSString (data: data!, encoding: NSUTF8StringEncoding)
                print("[Error] Deserialize Json: \(jsonStr)")
            }
        
        }
        
        task.resume()
        
        return responseCode
    }
    
    
    public func HttpGetRequest (urlStr: String) -> AnyObject? {
        
        var obj: AnyObject? = nil
        
        let request = NSMutableURLRequest (URL: NSURL(string: SysConstants.Base_Url + urlStr)!)
        let session = NSURLSession.sharedSession()
        request.HTTPMethod = "GET"
        
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        request.addValue("application/json", forHTTPHeaderField: "Accept")
        
        let task = session.dataTaskWithRequest(request) {data, response, error in guard data != nil else {
            print("[Error] HttpRequest: \(error)")
            return
            }
            
            do {
                if let json = try NSJSONSerialization.JSONObjectWithData(data!, options: []) as? NSDictionary {
                    let success = json["success"] as? Int
                    obj = json;
                    print("Success: \(success)")
                } else {
                    let jsonStr = NSString (data: data!, encoding: NSUTF8StringEncoding)
                    print("[Error] Deserialize Json: \(jsonStr)")
                }
            } catch let parseError {
                print(parseError)
                
                let jsonStr = NSString (data: data!, encoding: NSUTF8StringEncoding)
                print("[Error] Deserialize Json: \(jsonStr)")
            }
            
        }
        
        task.resume()
        
        return obj
    }
}