//
//  Item.h
//  TableView
//
//  Created by Admin on 11/3/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Item : NSObject

@property (nonatomic, strong) NSString *imageName;

@property (nonatomic, strong) NSString *title;

-(instancetype) initWithImageName: (NSString*) imageName
              andTitle: (NSString*) title;

@end