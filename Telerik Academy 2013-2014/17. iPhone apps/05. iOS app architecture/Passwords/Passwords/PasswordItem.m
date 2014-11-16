//
//  PasswordItem.m
//  Passwords
//
//  Created by Admin on 11/2/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import "PasswordItem.h"

@implementation PasswordItem

-(instancetype) initWithUsername: (NSString *) username
                     andPassword: (NSString *) password
               andEncryptionCode: (NSString *) encryptionCode {
    self = [super init];
    
    if(self) {
        self.username = username;
        self.password = password;
        self.encryptionCode = encryptionCode;
    }
    
    return self;
}

@end