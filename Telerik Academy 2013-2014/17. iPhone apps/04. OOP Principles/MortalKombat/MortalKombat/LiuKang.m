#import "LiuKang.h"
#import "Skill.h"

@implementation LiuKang

-(instancetype) initCharacter {
    NSArray *skills = @[
                        [[Skill alloc] initWithName: @"Brutal Kick" damage: 5 andPower: 10],
                        [[Skill alloc] initWithName: @"Mines" damage: 15 andPower: 15],
                        [[Skill alloc] initWithName: @"Rage" damage: 10 andPower: 5]
                        ];
    
    self = [super initWithName: @"Liu Kang" andSetOfSkills: skills];
    
    return self;
}

@end