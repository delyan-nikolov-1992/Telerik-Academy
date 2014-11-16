#import <Foundation/Foundation.h>

@interface Event : NSObject

@property (nonatomic) NSString *title;

@property (nonatomic) NSString *category;

@property (nonatomic) NSString *description;

@property (nonatomic) NSDate *date;

@property (nonatomic) NSMutableArray *guestList;

-(id) init;

-(void) addGuest: (NSString *) guest;

@end