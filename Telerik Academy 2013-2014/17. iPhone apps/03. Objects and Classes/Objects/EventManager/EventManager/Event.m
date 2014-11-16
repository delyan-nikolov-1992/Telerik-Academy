#import "Event.h"

#define trimAll(object)[object stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]]

@implementation Event

NSString *_title;
NSString *_category;
NSString *_description;
NSDate *_date;


-(id)init{
    self = [super self];
    
    if (self) {
        self.guestList = [[NSMutableArray alloc] init];
    }
    
    return self;
}

-(void) addGuest:(NSString *)guest{
    
    if ([trimAll(guest) length] > 0) {
        [self.guestList addObject:guest];
    }
    else{
        [NSException raise:@"Cannot add empty guest name" format:@"Guest name %@ is invalid", guest];
    }
}

-(void) setTitle:(NSString *)title{
    
    if ([trimAll(title) length] > 0) {
        _title = title;
    }
    else{
        [NSException raise:@"Invalid title value" format:@"title %@ is invalid", title];
    }
}

-(void) setCategory:(NSString *)category{
    if ([trimAll(category) length] > 0) {
        _category = category;
    }
    else{
        [NSException raise:@"Invalid category value" format:@"category %@ is invalid", category];
    }}

-(void) setDescription:(NSString *)description{
    if ([trimAll(description) length] > 0) {
        _description = description;
    }else{
        [NSException raise:@"Invalid description value" format:@"description %@ is invalid", description];
    }
}

@end