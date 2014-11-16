//
//  PasswordItem.h
//  Passwords
//
//  Created by Admin on 11/2/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface PasswordItem : NSObject

@property(nonatomic, strong) NSString* username;

@property(nonatomic, strong) NSString* password;

@property(nonatomic, strong) NSString* encryptionCode;

-(instancetype) initWithUsername: (NSString *) username
                     andPassword: (NSString *) password
               andEncryptionCode: (NSString *) encryptionCode;

@end