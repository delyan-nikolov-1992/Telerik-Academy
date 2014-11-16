#import <Foundation/Foundation.h>

#import "LiuKang.h"
#import "Scorpion.h"
#import "Raiden.h"
#import "JohnnyCage.h"
#import "SubZero.h"

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        NSArray *characters = @[
                            [[LiuKang alloc] initCharacter],
                            [[Scorpion alloc] initCharacter],
                            [[Raiden alloc] initCharacter],
                            [[JohnnyCage alloc] initCharacter],
                            [[SubZero alloc] initCharacter]
                            ];
        
        [[characters objectAtIndex:0] punch: [characters objectAtIndex:1]];
        [[characters objectAtIndex:0] useSkillAt: 0 against: [characters objectAtIndex:1]];
        [[characters objectAtIndex:3] kick: [characters objectAtIndex:0]];
        [[characters objectAtIndex:0] useSkillAt: 1 against: [characters objectAtIndex:2]];
        [[characters objectAtIndex:2] punch: [characters objectAtIndex:4]];
        [[characters objectAtIndex:4] punch: [characters objectAtIndex:1]];
        [[characters objectAtIndex:2] useSkillAt: 2 against: [characters objectAtIndex:3]];
        [[characters objectAtIndex:3] kick: [characters objectAtIndex:2]];
        [[characters objectAtIndex:1] useSkillAt: 0 against: [characters objectAtIndex:4]];
        [[characters objectAtIndex:4] useSkillAt: 1 against: [characters objectAtIndex:1]];
        [[characters objectAtIndex:4] punch: [characters objectAtIndex:1]];
        [[characters objectAtIndex:4] useSkillAt: 1 against: [characters objectAtIndex:1]];
        [[characters objectAtIndex:4] punch: [characters objectAtIndex:1]];
        [[characters objectAtIndex:4] punch: [characters objectAtIndex:1]];
        [[characters objectAtIndex:4] useSkillAt: 1 against: [characters objectAtIndex:1]];
        [[characters objectAtIndex:4] useSkillAt: 1 against: [characters objectAtIndex:1]];
    }
    
    return 0;
}