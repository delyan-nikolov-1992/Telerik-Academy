#import "SubZero.h"
#import "Skill.h"

@implementation SubZero

-(instancetype) initCharacter {
    NSArray *skills = @[
                        [[Skill alloc] initWithName: @"Branislav" damage: 5 andPower: 10],
                        [[Skill alloc] initWithName: @"Hara-Kiri" damage: 15 andPower: 35],
                        [[Skill alloc] initWithName: @"Rage" damage: 10 andPower: 5]
                        ];
    
    self = [super initWithName: @"Sub-Zero" andSetOfSkills: skills];
    
    return self;
}


@end