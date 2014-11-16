#import "Character.h"
#import "Skill.h"

@implementation Character

const int INITIAL_LIFE = 100;
const int INITIAL_POWER = 100;
const int PUNCH_DAMAGE = 10;
const int KICK_DAMAGE = 20;
const int POWER_PRODUCT = 5;

-(instancetype) initWithName: (NSString *) name
                 andSetOfSkills: (NSArray *) setOfSkills {
    self = [super init];
    
    if(self) {
        self.name = name;
        self.setOfSkills = setOfSkills;
        self.life = INITIAL_LIFE;
        self.power = INITIAL_POWER;
    }
    
    return self;
}

-(void) punch: (Character*) other {
    if(other.life > 0) {
        other.life -= PUNCH_DAMAGE;
        self.power += POWER_PRODUCT;
        
        if(other.life < 0) {
            other.life = 0;
        }
        
        if(self.power > INITIAL_POWER) {
            self.power = INITIAL_POWER;
        }
        
        NSLog(@"%@ punched %@!", self.name, other.name);
        NSLog(@"%@", self);
        NSLog(@"%@", other);
    } else {
        NSLog(@"%@ is already dead!", other.name);
    }
}

-(void) kick: (Character*) other {
    if(other.life > 0) {
        other.life -= KICK_DAMAGE;
        self.power += POWER_PRODUCT;
        
        if(other.life < 0) {
            other.life = 0;
        }
        
        if(self.power > INITIAL_POWER) {
            self.power = INITIAL_POWER;
        }
        
        NSLog(@"%@ kicked %@!", self.name, other.name);
        NSLog(@"%@", self);
        NSLog(@"%@", other);
    } else {
        NSLog(@"%@ is already dead!", other.name);
    }
}

-(void) useSkillAt: (int) position
           against: (Character*) other {
    if(other.life > 0) {
        if(position >= 0 && position < self.setOfSkills.count) {
            Skill *skill = [self.setOfSkills objectAtIndex: position];
            
            if(self.power >= skill.power) {
                self.power -= skill.power;
                other.life -= skill.damage;
                
                if(other.life < 0) {
                    other.life = 0;
                }
        
                NSLog(@"%@ used skill %@ against %@!", self.name, skill.name, other.name);
                NSLog(@"%@", self);
                NSLog(@"%@", other);
            } else {
                NSLog(@"%@ has not enough power for skill %@!", self.name, skill.name);
            }
        } else {
            NSLog(@"%@ has no such skill!", self.name);
        }
    } else {
        NSLog(@"%@ is already dead!", other.name);
    }
}

- (NSString *)description {
    return [NSString stringWithFormat: @"Name: %@; Life: %d; Power: %d", self.name, self.life, self.power];
}

@end