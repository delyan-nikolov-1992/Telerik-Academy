#import <UIKit/UIKit.h>

@interface WebViewController : UIViewController
@property (retain, nonatomic) IBOutlet UIWebView *webView;
@property (retain, nonatomic) NSString *str;

-(id) initWithString:(NSString *) str;
@end
