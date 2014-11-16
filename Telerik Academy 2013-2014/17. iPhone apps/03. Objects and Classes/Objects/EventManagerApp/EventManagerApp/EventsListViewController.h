//
//  EventsListViewController.h
//  EventManagerApp 07-07-36-812
//
//  Created by admin on 10/23/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface EventsListViewController : UIViewController{
    NSMutableArray *eventsList;
}
@property (weak, nonatomic) IBOutlet UILabel *eventsLabel;

-(void)setEventsList:(NSArray *)evs;
@end
