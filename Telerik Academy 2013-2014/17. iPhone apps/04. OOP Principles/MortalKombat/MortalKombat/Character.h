#import <Foundation/Foundation.h>
#import "Fightable.h"

@interface Character : NSObject<Fightable>

@property (nonatomic, strong) NSString *name;

@property (nonatomic, strong) NSArray *setOfSkills;

@property int life;

@property int power;

-(instancetype) initWithName: (NSString *) name
                 andSetOfSkills: (NSArray *) setOfSkills;

@end