#import "Skill.h"

@implementation Skill

-(instancetype) initWithName: (NSString *) name
                    damage: (int) damage
                    andPower: (int) power {
    self = [super init];
    
    if(self) {
        self.name = name;
        self.damage = damage;
        self.power = power;
    }
    
    return self;
}

@end