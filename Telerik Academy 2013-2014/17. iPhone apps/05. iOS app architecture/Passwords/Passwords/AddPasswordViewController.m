//
//  FirstViewController.m
//  Passwords
//
//  Created by Admin on 11/2/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import "AddPasswordViewController.h"
#import "PasswordItem.h"
#import "SimpleTableViewController.h"

@interface AddPasswordViewController ()

@property (weak, nonatomic) IBOutlet UITextField *usernameTextField;

@property (weak, nonatomic) IBOutlet UITextField *passwordTextField;

@property (weak, nonatomic) IBOutlet UITextField *encryptionCodeTextField;

- (IBAction)addItem:(id)sender;

@end

@implementation AddPasswordViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)addItem:(id)sender {
    PasswordItem* passwordItem = [[PasswordItem alloc] initWithUsername:self.usernameTextField.text andPassword:self.passwordTextField.text andEncryptionCode:self.encryptionCodeTextField.text];
    
    [SimpleTableViewController.passwords addObject:passwordItem];
    
    [[[UIAlertView alloc] initWithTitle:@"New password item"
                                message:@"Successfully added a new password item."
                               delegate:nil
                      cancelButtonTitle:@"OK"
                      otherButtonTitles:nil]
     show];
}

@end