//
//  EventsListViewController.m
//  EventManagerApp 07-07-36-812
//
//  Created by admin on 10/23/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "EventsListViewController.h"

@interface EventsListViewController ()

@end

@implementation EventsListViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    NSMutableString *eventsTitles = [[NSMutableString alloc] init];
    NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
    [dateFormatter setDateFormat:@"EEE MMM dd"];
    
    for (int i = 0; i < eventsList.count; i++) {
        [eventsTitles appendFormat:@"%@",[eventsList[i] title]];
        [eventsTitles appendFormat:@" Day:%@\n",[dateFormatter stringFromDate:[eventsList[i] date]]];
        
    }
    
    self.eventsLabel.text = eventsTitles;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void) setEventsList:(NSMutableArray *)evs{
    eventsList = evs;
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
