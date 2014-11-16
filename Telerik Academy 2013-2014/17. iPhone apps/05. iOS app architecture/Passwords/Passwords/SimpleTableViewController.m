//
//  SimpleTableViewController.m
//  Passwords
//
//  Created by Admin on 11/2/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import "SimpleTableViewController.h"
#import "PasswordItem.h"

@implementation SimpleTableViewController

+(NSMutableArray*) passwords {
    static NSMutableArray* result = nil;
    
    if(result == nil) {
        result = [NSMutableArray arrayWithObjects:
                  [[PasswordItem alloc] initWithUsername: @"first_user"
                                             andPassword: @"123456"
                                       andEncryptionCode: @"Encrypted"],
                  [[PasswordItem alloc] initWithUsername: @"second_user"
                                             andPassword: @"1234567"
                                       andEncryptionCode: @"Encrypted2"],
                  [[PasswordItem alloc] initWithUsername: @"third_user"
                                             andPassword: @"123456"
                                       andEncryptionCode: @"Encrypted"],
                  [[PasswordItem alloc] initWithUsername: @"fourth_user"
                                             andPassword: @"123456"
                                       andEncryptionCode: @"Encrypted"],
                  [[PasswordItem alloc] initWithUsername: @"fifth_user"
                                             andPassword: @"123456"
                                       andEncryptionCode: @"Encrypted"],
                  [[PasswordItem alloc] initWithUsername: @"sixth_user"
                                             andPassword: @"123456"
                                       andEncryptionCode: @"Encrypted"],
                  [[PasswordItem alloc] initWithUsername: @"seventh_user"
                                             andPassword: @"123456"
                                       andEncryptionCode: @"Encrypted"],
                  [[PasswordItem alloc] initWithUsername: @"eight_user"
                                             andPassword: @"123456"
                                       andEncryptionCode: @"Encrypted"], nil];
    }
    
    return result;
}

- (NSInteger) tableView:(UITableView *) tableView
  numberOfRowsInSection:(NSInteger) section {
    return [SimpleTableViewController.passwords count];
}

- (UITableViewCell *) tableView:(UITableView *) tableView
          cellForRowAtIndexPath:(NSIndexPath *) indexPath {
    static NSString *simpleTableIdentifier = @"SimpleTableItem";
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier: simpleTableIdentifier];
    
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault
                                      reuseIdentifier:simpleTableIdentifier];
    }
    
    PasswordItem *passwordItem = (PasswordItem* )[SimpleTableViewController.passwords objectAtIndex:indexPath.row];
    
    UILabel *usernameLabel = (UILabel*) [self.view viewWithTag:1000];
    UILabel *encryptionCodeLabel = (UILabel*) [self.view viewWithTag:2000];
    
    [usernameLabel setText: passwordItem.username];
    [encryptionCodeLabel setText: passwordItem.encryptionCode];
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    [tableView deselectRowAtIndexPath:indexPath animated:YES];
    
    PasswordItem *passwordItem = (PasswordItem* )[SimpleTableViewController.passwords objectAtIndex:indexPath.row];
    
    [[[UIAlertView alloc] initWithTitle:@"Password"
                                message: [NSString stringWithFormat:@"The password for this user is: %@",
                                          passwordItem.password ]
                               delegate:nil
                      cancelButtonTitle:@"OK"
                      otherButtonTitles:nil]
     show];
}

@end