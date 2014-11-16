//
//  ViewController.h
//  EventManagerApp
//
//  Created by admin on 10/23/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "EventManager.h"
#import "Event.h"
#import "EventsListViewController.h"

@interface MainViewController : UIViewController{
    EventManager *eventManager;
    __weak IBOutlet UIButton *viewEvents;
    __weak IBOutlet UIButton *addEvent;
    __weak IBOutlet UILabel *contentLabel;
   
    
    __weak IBOutlet UITextField *eventTitleInput;
}
@property (weak, nonatomic) IBOutlet UIDatePicker *datePicker;
- (IBAction)addEventClick:(id)sender;

-(IBAction)unwindToMain:(UIStoryboardSegue *)segue;

@end

