//
//  ViewController.m
//  EventManagerApp
//
//  Created by admin on 10/23/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#define trimAll(object)[object stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]]

#import "MainViewController.h"


@interface MainViewController ()

@end

@implementation MainViewController

-(id)initWithCoder:(NSCoder *)aDecoder{
    self = [super initWithCoder:aDecoder];
    
    if (self) {
        eventManager = [[EventManager alloc] init];
    }
    
    return self;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


- (IBAction)addEventClick:(id)sender {
    Event *newEvent = [[Event alloc] init];
    NSString *eventTitle = eventTitleInput.text;
    NSDate *eventDate = [self.datePicker date];
    
    if ([trimAll(eventTitle) length] > 0) {
        eventTitleInput.text = @"";
        
        [newEvent setTitle:eventTitle];
        [newEvent setDate:eventDate];
                
        [eventManager createEvent:newEvent];
    }
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"AddEvent" message:@"Added Event To List" delegate:nil cancelButtonTitle:@"Okay" otherButtonTitles:nil, nil];
    [alert show];
    [eventTitleInput resignFirstResponder];
    
}

-(BOOL)textFieldShouldReturn:(UITextField *)textField{
    [eventTitleInput resignFirstResponder];
    
    return YES;
}

-(IBAction)unwindToMain:(UIStoryboardSegue *)segue{
    
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender{
    
    if ([segue.identifier isEqualToString:@"viewEvents"]) {
        
        EventsListViewController *controller = (EventsListViewController *)segue.destinationViewController;
        NSArray *events = [eventManager eventsList];
        
        [controller setEventsList:events];
    }
}


//method for making the keyboard disappear
-(void) touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event{
    [self.view endEditing:YES];
}
@end
