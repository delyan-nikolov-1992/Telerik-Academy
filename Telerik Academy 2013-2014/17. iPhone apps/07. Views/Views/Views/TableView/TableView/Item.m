//
//  Item.m
//  TableView
//
//  Created by Admin on 11/3/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import "Item.h"

@implementation Item

-(instancetype) initWithImageName: (NSString*) imageName
                         andTitle: (NSString*) title {
    self = [super init];
    
    if(self) {
        self.imageName = imageName;
        self.title = title;
    }
    
    return self;
}

@end