#import "Scorpion.h"
#import "Skill.h"

@implementation Scorpion

-(instancetype) initCharacter {
    NSArray *skills = @[
                        [[Skill alloc] initWithName: @"Scorps" damage: 5 andPower: 10],
                        [[Skill alloc] initWithName: @"Clynch" damage: 15 andPower: 15],
                        [[Skill alloc] initWithName: @"Rage" damage: 10 andPower: 5]
                        ];
    
    self = [super initWithName: @"Scorpion" andSetOfSkills: skills];
    
    return self;
}

@end