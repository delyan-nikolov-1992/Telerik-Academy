#import "Raiden.h"
#import "Skill.h"

@implementation Raiden

-(instancetype) initCharacter {
    NSArray *skills = @[
                        [[Skill alloc] initWithName: @"Storm" damage: 5 andPower: 10],
                        [[Skill alloc] initWithName: @"Thunder" damage: 15 andPower: 15],
                        [[Skill alloc] initWithName: @"Rage" damage: 10 andPower: 5]
                        ];
    
    self = [super initWithName: @"Raiden" andSetOfSkills: skills];
    
    return self;
}


@end