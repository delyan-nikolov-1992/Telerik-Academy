//
//  ViewController.m
//  TableView
//
//  Created by Admin on 11/3/14.
//  Copyright (c) 2014 Admin. All rights reserved.
//

#import "TableViewController.h"
#import "Item.h"

@interface TableViewController ()

@end

@implementation TableViewController {
    NSMutableArray *items;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    items = [[NSMutableArray alloc] initWithObjects:
             [[Item alloc] initWithImageName:@"asp.png" andTitle:@"ASP.NET"],
             [[Item alloc] initWithImageName:@"c#.png" andTitle:@"C# OOP"],
             [[Item alloc] initWithImageName:@"cpp.png" andTitle:@"C++"],
             [[Item alloc] initWithImageName:@"css.png" andTitle:@"CSS"],
             [[Item alloc] initWithImageName:@"html.png" andTitle:@"HTML"],
             [[Item alloc] initWithImageName:@"js.png" andTitle:@"JavaScript"],
             [[Item alloc] initWithImageName:@"php.png" andTitle:@"PHP"], nil];
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return [items count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *cellIdentifier = @"TableViewCell";

    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIdentifier];
    
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:cellIdentifier];
    }
    
    Item *currentItem = (Item*) [items objectAtIndex:indexPath.row];
    
    UIImageView *image = (UIImageView*) [self.view viewWithTag:1];
    UILabel *titleLabel = (UILabel*) [self.view viewWithTag:2];
    
    [image setImage: [UIImage imageNamed:currentItem.imageName]];
    [titleLabel setText: currentItem.title];
    
    return cell;
}

@end