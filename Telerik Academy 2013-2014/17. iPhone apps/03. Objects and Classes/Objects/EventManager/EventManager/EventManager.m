#import "EventManager.h"

@implementation EventManager

-(id)init{
    self = [super self];
    
    if (self) {
        
        _eventsList = [[NSMutableArray alloc] init];
    }
    
    return self;
}

-(void) setDate:(NSDate *)date{
    self.date = [[NSDate alloc] init];
}

-(void) createEvent: (Event *) event{
    [_eventsList addObject:event];
    
}

-(NSArray *) eventsList{
    return _eventsList;
}


-(NSArray *) listEventsByCategory: (NSString *) category{
    NSPredicate *predicate = [NSPredicate predicateWithFormat:@"SELF.category LIKE [c] %@",category];
    NSArray *filtered = [_eventsList filteredArrayUsingPredicate:predicate];
    
    return filtered;
}

-(void) sortEventsByDate{
    NSSortDescriptor *descriptor = [[NSSortDescriptor alloc] initWithKey:@"date" ascending:YES];
    
    NSMutableArray *sortDescriptors = [NSMutableArray arrayWithObject:descriptor];
    NSArray *sorted = [_eventsList sortedArrayUsingDescriptors:sortDescriptors];
    
    _eventsList = [sorted mutableCopy];
}

-(void) sortEventsByTitle{
    NSSortDescriptor *descriptor = [[NSSortDescriptor alloc] initWithKey:@"title" ascending:YES];
    
    NSMutableArray *sortDescriptors = [NSMutableArray arrayWithObject:descriptor];
    NSArray *sorted = [_eventsList sortedArrayUsingDescriptors:sortDescriptors];
    
    _eventsList = [sorted mutableCopy];
}

@end