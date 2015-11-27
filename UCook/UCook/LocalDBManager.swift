//
//  LocalDBManager.swift
//  UCook
//
//  Created by Yuan Lu on 2015-11-26.
//  Copyright © 2015 PANDA. All rights reserved.
//

import Foundation
    
    internal let SQLITE_STATIC = unsafeBitCast(0, sqlite3_destructor_type.self)
    internal let SQLITE_TRANSIENT = unsafeBitCast(-1, sqlite3_destructor_type.self)
    
    let documentsPath = try! NSFileManager.defaultManager().URLForDirectory(.DocumentDirectory, inDomain: .UserDomainMask, appropriateForURL: nil, create: false)
    
    // ToDo : Relative Path to sqlite db file, check it
    
    // file url form " /path/path/path/ImgMetaInfoDB.sqlite "

    let fileURL = documentsPath.URLByAppendingPathComponent("ImgMetaInfoDB\(SysConstants.Internal_DB_Version).sqlite")
    
    // database pointer
    // ToDo : find what this does
    var db: COpaquePointer = nil
    
    // statement is like query I think
    var statement: COpaquePointer = nil
    
    
    func CreateOrOpen () {
        // Print Document Directory Path
        print("\(documentsPath)")
        // open database
        if sqlite3_open(fileURL.path!, &db) != SQLITE_OK {
            assertionFailure( "ERROR:(FUNC CreateOrOpen) can not open database..." )
        }
        
        if sqlite3_exec(db, "create table if not exists imageTable (id integer primary key autoincrement, nameOfimage text, dateOfimage datetime default (datetime('now')))", nil,nil,nil) != SQLITE_OK {
            let errmsg = String.fromCString(sqlite3_errmsg(db))
            assertionFailure( "ERROR:(FUNC CreateOrOpen) can not create database... \(errmsg)" )
        }
    }
    
    
    func InsertData(nameOfimage:String) {
        
        // Check if db has been open
        // Not checking db - speed up query
        
        // Use sqlite3_prepare_v2 to prepare sql with ? placeholder to which we'll bind value
        // sql prepare -> bind -> step
        
        // 1.Prepare Statement
        if sqlite3_prepare_v2(db, "insert into imageTable (nameOfimage) values (?)", -1, &statement, nil) != SQLITE_OK {
            let errmsg = String.fromCString(sqlite3_errmsg(db))
            assertionFailure( "ERROR:(FUNC INSERT) can not prepare statement...\(errmsg)" )
        }
        if sqlite3_bind_text(statement, 1, nameOfimage, -1, SQLITE_TRANSIENT) != SQLITE_OK {
            // 2. bind statement text
            let errmsg = String.fromCString(sqlite3_errmsg(db))
            assertionFailure( "ERROR:(FUNC INSERT) can not bind statement...\(errmsg)" )
        }
        // 3.sql step
        if sqlite3_step(statement) != SQLITE_DONE {
            let errmsg = String.fromCString(sqlite3_errmsg(db))
            assertionFailure( "ERROR:(FUNC INSERT) can not insert... \(errmsg)" )
        }
        // Finalize prepared statement to recover memory associated with that prepared statement
        if sqlite3_finalize(statement) != SQLITE_OK  {
            let errmsg = String.fromCString(sqlite3_errmsg(db))
            assertionFailure( "ERROR:(FUNC INSERT) can not finalize statement... \(errmsg)" )
        }
    }
    
