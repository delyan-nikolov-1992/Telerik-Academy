//
//  SecondViewController.m
//  Passwords
//
//  Created by Admin on 11/2/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import "RandomPasswordViewController.h"
#import "PasswordItem.h"
#import "SimpleTableViewController.h"

@interface RandomPasswordViewController ()

@property (weak, nonatomic) IBOutlet UITextField *usernameTextField;

@property (weak, nonatomic) IBOutlet UITextField *encryptionCodeTextField;

- (IBAction)addRandom:(id)sender;

@end

@implementation RandomPasswordViewController

const NSString *letters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)addRandom:(id)sender {
    NSString *password = [self randomStringWithLength: arc4random_uniform(20)];
    
    PasswordItem* passwordItem = [[PasswordItem alloc] initWithUsername:self.usernameTextField.text andPassword:password andEncryptionCode:self.encryptionCodeTextField.text];
    
    [SimpleTableViewController.passwords addObject:passwordItem];
    
    [[[UIAlertView alloc] initWithTitle:@"New password item"
                                message:@"Successfully added a new random password item."
                               delegate:nil
                      cancelButtonTitle:@"OK"
                      otherButtonTitles:nil]
     show];
}

-(NSString *) randomStringWithLength: (int) len {
    
    NSMutableString *randomString = [NSMutableString stringWithCapacity: len];
    
    for (int i=0; i<len; i++) {
        [randomString appendFormat: @"%C", [letters characterAtIndex: arc4random_uniform([letters length])]];
    }
    
    return randomString;
}

@end