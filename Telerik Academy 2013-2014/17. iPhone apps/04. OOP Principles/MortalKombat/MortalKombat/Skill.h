#import <Foundation/Foundation.h>

@interface Skill : NSObject

@property (nonatomic, strong) NSString *name;

@property int damage;

@property int power;

-(instancetype) initWithName: (NSString *) name
                    damage: (int) damage
                    andPower: (int) power;

@end