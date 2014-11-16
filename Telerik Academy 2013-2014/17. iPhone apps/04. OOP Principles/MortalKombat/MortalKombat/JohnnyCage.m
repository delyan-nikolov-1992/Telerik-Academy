#import "JohnnyCage.h"
#import "Skill.h"

@implementation JohnnyCage

-(instancetype) initCharacter {
    NSArray *skills = @[
                        [[Skill alloc] initWithName: @"Sunglass kill" damage: 5 andPower: 10],
                        [[Skill alloc] initWithName: @"Tiferich" damage: 15 andPower: 15],
                        [[Skill alloc] initWithName: @"Rage" damage: 10 andPower: 5]
                        ];
    
    self = [super initWithName: @"Johnny Cage" andSetOfSkills: skills];
    
    return self;
}


@end